import { useEffect, useState } from 'react';
import { Alert, Button, Container, Snackbar, Typography } from '@mui/material';

import TaskTable from '../components/tables/TaskTable';
import HomeHeader from '../components/headers/HomeHeader';
import TaskFilter from '../components/filters/TaskFilter';
import Task from '../models/Task';
import TaskService from '../services/TaskService';
import TaskModal from '../components/modals/TaskModal';
import ValidationError from '../models/ValidationError';
import Message from '../models/Message';
import Paginated from '../models/Paginated';
import TaskDialog from '../components/dialogs/TaskDialog';

const Home = () => {
    const taskService = new TaskService();

    const [openCreateModal, setOpenCreateModal] = useState<boolean>(false);
    const [openUpdateModal, setOpenUpdateModal] = useState<boolean>(false);
    const [message, setMessage] = useState<Message>({open: false, value: '', severity: "success" });
    const [task, setTask] = useState<Task>();
    const [taskDelete, setTaskDelete] = useState<Task>();
    const [name, setName] = useState<string>('');
    const [paginated, setPaginated] = useState<Paginated<Task>>();
    const [validation, setValidation] = useState<ValidationError>();

    const onSearchClick = async (name: string) => {
        const response = await taskService.searchAsync(name, 1);
        setName(name);
        setPaginated(response.data);
    };

    const onClearClick = async () => {
        const response = await taskService.searchAsync('', 1);
        setPaginated(response.data);
    };

    const onPageChange = async (page: number) => {
        if (page !== paginated?.pageNumber) {
            const response = await taskService.searchAsync(name, page);
            setPaginated(response.data);    
        }
    }

    const onEditClick = (task: Task) => {
        setTask(task);
        setOpenUpdateModal(true);
        console.log(task);
    }
    const onDeleteClick = (task: Task) => {
        setTaskDelete(task);
    }

    const onDialogCloseClick = () => {
        setTaskDelete(undefined);
    };

    const onDialogSaveClick = () => {
        if(taskDelete) {
            taskService.removeAsync(taskDelete.id)
                       .catch(error => console.log(error))
                       .then(response => {
                            console.log(response);
                            setMessage({open: true, value: `Tarefa '${taskDelete.title}' excluída com sucesso!`, severity: "success"});
                            setTaskDelete(undefined);
                        });
        }
    };
    
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
        taskService.searchAsync('', 1)
                   .then(response => setPaginated(response.data));
    }, []);

    return (
        <Container>
            <HomeHeader onButtonClick={()=> setOpenCreateModal(true)}/>
            <TaskFilter onSearchClick={onSearchClick} onClearClick={onClearClick}/>
            <TaskTable paginated={paginated} onDeleteClick={onDeleteClick} onEditClick={onEditClick} onPageChange={onPageChange}/>
            <TaskModal open={openCreateModal} mode="create" errors={validation?.errors} onModalSaveClick={onCreateModalSaveClick} onModalCloseClick={onCreateModalCloseClick}/>
            <TaskModal open={openUpdateModal} mode="update" value={task} onModalSaveClick={onUpdateModalSaveClick} onModalCloseClick={onUpdateModalCloseClick}/>
            <Snackbar open={message.open} anchorOrigin={{horizontal: "center", vertical: "top"}} autoHideDuration={5000}>
                <Alert severity={message.severity} variant="filled" sx={{width:400}} onClose={()=>{}}>
                    <Typography variant='body1' component="div">{message.value}</Typography>
                </Alert>
            </Snackbar>
            <TaskDialog title='Excluir tarefa' description='Deseja realmente excluir a tarefa?' value={taskDelete} btnOk='Salvar' btnCancel='Cancelar' onDialogCloseClick={onDialogCloseClick} onDialogSaveClick={onDialogSaveClick} />
        </Container>
    );
};

export default Home;



