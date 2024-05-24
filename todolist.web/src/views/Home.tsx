import { useEffect, useState } from 'react';
import { Alert, Container, Snackbar, Typography } from '@mui/material';

import TaskTable from '../components/tables/TaskTable';
import HomeHeader from '../components/headers/HomeHeader';
import TaskFilter from '../components/filters/TaskFilter';
import Task from '../models/Task';
import TaskService from '../services/TaskService';
import TaskModal from '../components/modals/TaskModal';
import ValidationError from '../models/ValidationError';
import Message from '../models/Message';

const Home = () => {
    const taskService = new TaskService();
    
    const [openCreateModal, setOpenCreateModal] = useState<boolean>(false);
    const [openUpdateModal, setOpenUpdateModal] = useState<boolean>(false);
    const [message, setMessage] = useState<Message>({open: false, value: '', severity: "success" });
    const [task, setTask] = useState<Task>();
    const [tasks, setTasks] = useState<Task[]>([]);
    const [validation, setValidation] = useState<ValidationError>();

    const onSearchClick = async (name: string) => {
        const response = await taskService.searchAsync(name);
        setTasks(response.data);
    };

    const onClearClick = async () => {
        const response = await taskService.searchAsync('');
        setTasks(response.data);
    };

    const onEditClick = (task: Task) => {
        setTask(task);
        setOpenUpdateModal(true);
        console.log(task);
    }
    const onDeleteClick = (task: Task) => {console.log(task);}
    
    const onCreateModalCloseClick = () => {
        setOpenCreateModal(false);
        setValidation(undefined);
    }

    const onCreateModalSaveClick = (task: Task) => {
        taskService.createAsync(task)
        .then(response => {
            setOpenCreateModal(false);
            setMessage({open: true, value: `Tarefa '${response.data.title}' adicionada com sucesso!`, severity: "success"});
        
        })
        .catch(error => {
             if(error.response.status === 400) {
                 setValidation(error.response.data);
                 console.log(error.response.data);
             } else if(error.response.status === 404) {
                 console.log(error.response.data);
             } else {
                 console.log(error);
             }
        })
    }

    const onUpdateModalCloseClick = () => {
        setOpenUpdateModal(false);
        setValidation(undefined);
    }
    
    const onUpdateModalSaveClick = (task: Task) => {
        console.log(task);

    }

    useEffect(() => {
        taskService.searchAsync('')
                   .then(response => setTasks(response.data));
    }, []);

    return (
        <Container>
            <HomeHeader onButtonClick={()=> setOpenCreateModal(true)}/>
            <TaskFilter onSearchClick={onSearchClick} onClearClick={onClearClick}/>
            <TaskTable tasks={tasks} onDeleteClick={onDeleteClick} onEditClick={onEditClick}/>
            <TaskModal open={openCreateModal} mode="create" errors={validation?.errors} onModalSaveClick={onCreateModalSaveClick} onModalCloseClick={onCreateModalCloseClick}/>
            <TaskModal open={openUpdateModal} mode="update" value={task} onModalSaveClick={onUpdateModalSaveClick} onModalCloseClick={onUpdateModalCloseClick}/>
            <Snackbar open={message.open} anchorOrigin={{horizontal: "center", vertical: "top"}}>
                <Alert severity={message.severity} variant="filled" sx={{width:400}}>
                    <Typography variant='body1' component="div">{message.value}</Typography>
                </Alert>
            </Snackbar>
        </Container>
    );
};

export default Home;



