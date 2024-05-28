import { useEffect, useState } from 'react';
import { Button,  Container, Backdrop, Grid, AppBar, Toolbar, Stack, Card, CardContent, CardHeader, TextField, FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@mui/material';
import { ptBR } from '@mui/x-date-pickers/locales';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker'
import Status from '../../models/Status';
import Task from '../../models/Task';
import dayjs from 'dayjs';
import TaskService from '../../services/TaskService';
import ValidationError from '../../models/ValidationError';
import Message from '../../models/Message';


interface TaskModalProps {
    open?: boolean;
    value?: Task;
    mode?: 'create' | 'update';
    status?: Status[];
    errors?: {[key: string]: string[]};
    onModalSuccess?: (message: Message) => void;
    onModalError?: (message: Message) => void;
    onModalClose?:() => void;
}

const TaskModal : React.FC<TaskModalProps> = ({open, value, mode, status, onModalSuccess, onModalError, onModalClose}) => {
    const  defaultTask = {id: 0, title: "", description: "", statusId: 0, startDate: new Date(), targetDate: new Date()};

    const [task, setTask] = useState<Task>(value ?? defaultTask);
    const [validation, setValidation] = useState<ValidationError>();

    const taskService = new TaskService();

    const onSaveClick = () => {
        if(mode === "create") {
            taskService.createAsync(task)
            .then(response => {
                setValidation(undefined);
                setTask(defaultTask);
                onModalSuccess && onModalSuccess({open: true, value: `Tarefa '${response.data.title}' adicionada com sucesso!`, severity: "success"})
            })
            .catch(error => {
                if(error.response.status === 400) {
                    setValidation(error.response.data);
                } else if(error.response.status === 409) {
                    onModalError && onModalError({open: true, value: error.response.data.detail, severity: "error"});
                } else {
                    onModalError && onModalError({open: true, value: 'Aconteceu um erro inesperado, tente novamente mais tarde!', severity: "error"});
                }
            });
        } else {
            taskService.updateAsync(task)
            .then(response => {
                setValidation(undefined);
                onModalSuccess && onModalSuccess({open: true, value: `Tarefa '${response.data.title}' atualizada com sucesso!`, severity: "success"});
            })
            .catch(error => {
                if(error.response.status === 400) {
                    setValidation(error.response.data);
                } else if(error.response.status === 409) {
                    onModalError && onModalError({open: true, value: error.response.data.detail, severity: "error"});
                } else {
                    onModalError && onModalError({open: true, value: 'Aconteceu um erro inesperado, tente novamente mais tarde!', severity: "error"});
                }
            })
        }
    };

    const resetError = (name: string) => {
        if(validation && validation.errors && validation.errors[name]?.length > 0) {
            validation.errors[name] = [];
            setValidation(validation);
        }
    }; 

    const hasError = (name:string) : boolean =>   {
        if(validation && validation.errors) {
            return validation.errors[name]?.length > 0;
        }
        
        return false;
    }

    const getError = (name: string) : string => {
        if(validation && validation.errors && validation.errors[name]?.length > 0) {
            return validation.errors[name][0];
        }
        
        return '';
    }

    useEffect(() => {
        if (value && value !== task) {
            setTask(value);
            console.log('useeffect')
        }
    }, [value]);

    return (
        <Backdrop open={open ?? false} sx={{backgroundColor:"white"}}>
            <AppBar component="nav" position="absolute" elevation={0} color='transparent' >
                <Container>
                    <Toolbar disableGutters>
                        <Stack direction="row" justifyContent="flex-end" spacing={1} width="100%">
                            <Button variant="outlined" onClick={() => onModalClose && onModalClose()} sx={{width:100}}>Cancelar</Button>
                            <Button variant="contained" onClick={onSaveClick} sx={{width:100}}>Salvar</Button>
                        </Stack>
                    </Toolbar>
                    <Card variant='outlined'>
                        <CardHeader title={mode === "update" ? "Atualizar tarefa" : "Cadastrar tarefa"}>
                        </CardHeader>
                        <CardContent>
                            <Grid container spacing={3}>
                                <Grid item xs={12} lg={6}>
                                    <TextField name="Title" label="Titulo" value={task?.title} onChange={(event) => {setTask({...task, title: event.target.value}); resetError(event.target.name);}} error={hasError("Title")} helperText={getError("Title")} fullWidth/>
                                </Grid>
                                <Grid item xs={12} lg={6}>
                                    <FormControl error={hasError("StatusId")} fullWidth>
                                        <InputLabel>Status</InputLabel>
                                        <Select name="StatusId" value={task.statusId} onChange={(event) => {setTask({...task, statusId: Number(event.target.value)});resetError(event.target.name);}}>
                                            <MenuItem value={0}>Selecione</MenuItem>
                                            {
                                                status && status.length > 0 ? status.map(status => <MenuItem key={status.id} value={status.id}>{status.name}</MenuItem>) : []    
                                            }
                                        </Select>
                                        <FormHelperText>{getError("StatusId")}</FormHelperText>
                                    </FormControl>
                                </Grid> 
                                <Grid item xs={12} lg={6}>
                                    <FormControl error={hasError("StartDate")} fullWidth>
                                        <LocalizationProvider localeText={ptBR.components.MuiLocalizationProvider.defaultProps.localeText} dateAdapter={AdapterDayjs}>
                                            <DatePicker label="Data de início" value={dayjs(task.startDate)} onChange={(newValue) => {setTask({...task, startDate: dayjs(newValue).toDate()});resetError("StartDate");}} format='DD/MM/YYYY' sx={{width:'100%'}}/>
                                        </LocalizationProvider>
                                    <FormHelperText>{getError("StartDate")}</FormHelperText>
                                    </FormControl>
                                </Grid>
                                <Grid item xs={12} lg={6}>
                                    <FormControl error={hasError("TargetDate")} fullWidth>
                                        <LocalizationProvider localeText={ptBR.components.MuiLocalizationProvider.defaultProps.localeText} dateAdapter={AdapterDayjs}>
                                            <DatePicker label="Data de entrega" minDate={dayjs(task.startDate)} value={dayjs(task.targetDate)} onChange={(newValue) => {setTask({...task, targetDate: dayjs(newValue).toDate()});resetError("TargetDate");}} format='DD/MM/YYYY' sx={{width:'100%'}}/>
                                        </LocalizationProvider>
                                        <FormHelperText>{getError("TargetDate")}</FormHelperText>
                                    </FormControl>
                                </Grid>
                                <Grid item xs={12}>
                                    <TextField name="Description" label="Descrição" value={task.description} onChange={(event) =>  {setTask({...task, description: event.target.value}); resetError(event.target.name);}} error={hasError("Description")} helperText={getError("Description")} minRows={4} multiline fullWidth/>
                                </Grid>   
                            </Grid>
                        </CardContent>
                    </Card>
                </Container>
            </AppBar>
        </Backdrop>
    );
};

export default TaskModal;