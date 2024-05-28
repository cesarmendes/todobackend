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
import Paginated from '../models/Paginated';
import TaskDialog from '../components/dialogs/TaskDialog';
import StatusService from '../services/StatusService';
import Status from '../models/Status';

const Home = () => {
    const taskService = new TaskService();
    const statusService = new StatusService();

    const [searchLoading, setSearchLoading] = useState<boolean>(false);
    const [openCreateModal, setOpenCreateModal] = useState<boolean>(false);
    const [openUpdateModal, setOpenUpdateModal] = useState<boolean>(false);
    const [message, setMessage] = useState<Message>({open: false, value: '', severity: "success" });
    const [taskEdit, setTaskEdit] = useState<Task>();
    const [taskDelete, setTaskDelete] = useState<Task>();
    const [name, setName] = useState<string>('');
    const [paginated, setPaginated] = useState<Paginated<Task>>();
    const [validation, setValidation] = useState<ValidationError>();
    const [status, setStatus] = useState<Status[]>([]);

    const onSearchClick = (name: string, page?: number) => {
        setSearchLoading(true);
        setName(name);
        
        taskService.searchAsync(name, page ?? 1)
        .then(response => {
            response.data.items = response.data.items.map((task) =>{
                const s = status.find((item) => item.id === task.statusId);
                task.status = s?.name;
                return task;
            });

            setPaginated(response.data);
        })
        .catch(error => console.log(error))
        .finally(() => {
            setSearchLoading(false);
        });
    };

    const onClearClick = async () => {
        onSearchClick('');
    };

    const onPageChange = (page: number) => {
        if (page !== paginated?.pageNumber) {
            onSearchClick(name, page);
        }
    }

    const onEditClick = (task: Task) => {
        setTaskEdit(task);
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
            taskService
            .removeAsync(taskDelete.id)
            .then(response => {
                onSearchClick(name);
                setMessage({open: true, value: `Tarefa '${response.data.title}' excluída com sucesso!`, severity: "success"});
                setTaskDelete(undefined);
            })
            .catch(error => console.log(error));
        }
    };
    
    const onCreateModalCloseClick = () => {
        setValidation(undefined);
        setOpenCreateModal(false);
    }

    const onCreateModalSaveClick = (task: Task) => {
        taskService.createAsync(task)
        .then(response => {
            setValidation(undefined);
            setOpenCreateModal(false);
            setMessage({open: true, value: `Tarefa '${response.data.title}' adicionada com sucesso!`, severity: "success"});
            onSearchClick(name);
        })
        .catch(error => {
             if(error.response.status === 400) {
                 setValidation(error.response.data);
             } else if(error.response.status === 409) {
                setMessage({open: true, value: error.response.data.detail, severity: "error"});
             } else {
                setMessage({open: true, value: 'Aconteceu um erro inesperado, tente novamente mais tarde!', severity: "error"});
             }
        })
    }

    const onUpdateModalCloseClick = () => {
        setValidation(undefined);
        setOpenUpdateModal(false);
    }
    
    const onUpdateModalSaveClick = (task: Task) => {
        taskService.updateAsync(task)
        .then(response => {
            setValidation(undefined);
            setOpenUpdateModal(false);
            setMessage({open: true, value: `Tarefa '${response.data.title}' atualizada com sucesso!`, severity: "success"});
            onSearchClick(name);
        })
        .catch(error => {
            if(error.response.status === 400) {
                setValidation(error.response.data);
            } else if(error.response.status === 409) {
                setMessage({open: true, value: error.response.data.detail, severity: "error"});
            } else {
                setMessage({open: true, value: 'Aconteceu um erro inesperado, tente novamente mais tarde!', severity: "error"});
            }
        })
    }

    useEffect(() => {
        Promise.all([taskService.searchAsync('', 1), statusService.searchAsync('')])
               .then((values) => {
                values[0].data.items = values[0].data.items.map((task) =>{
                    const status = values[1].data.items.find((item) => item.id === task.statusId);
                    task.status = status?.name;
                    return task;
                });

                setPaginated(values[0].data);
                setStatus(values[1].data.items);
               });
    }, []);

    return (
        <Container>
            <HomeHeader onButtonClick={()=> setOpenCreateModal(true)}/>
            <TaskFilter onSearchClick={onSearchClick} onClearClick={onClearClick}/>
            <TaskTable loading={searchLoading} paginated={paginated} onDeleteClick={onDeleteClick} onEditClick={onEditClick} onPageChange={onPageChange}/>
            <TaskModal open={openCreateModal} mode="create" status={status} errors={validation?.errors} onModalSaveClick={onCreateModalSaveClick} onModalCloseClick={onCreateModalCloseClick}/>
            <TaskModal open={openUpdateModal} mode="update" status={status} errors={validation?.errors} value={taskEdit} onModalSaveClick={onUpdateModalSaveClick} onModalCloseClick={onUpdateModalCloseClick}/>
            <Snackbar open={message.open} anchorOrigin={{horizontal: "center", vertical: "top"}} autoHideDuration={5000} onClose={()=>{setMessage({open: false, severity: message.severity, value:''})}}>
                <Alert severity={message.severity} variant="filled" sx={{width:400}} onClose={()=>{setMessage({open: false, severity: message.severity, value:''});console.log('fechou');}}>
                    <Typography variant='body1' component="div">{message.value}</Typography>
                </Alert>
            </Snackbar>
            <TaskDialog title='Excluir tarefa' description='Deseja realmente excluir a tarefa?' value={taskDelete} btnOk='Excluir' btnCancel='Cancelar' onDialogCloseClick={onDialogCloseClick} onDialogSaveClick={onDialogSaveClick} />
        </Container>
    );
};

export default Home;



