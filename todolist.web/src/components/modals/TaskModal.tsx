import { useEffect, useState } from 'react';
import { Button,  Container, Backdrop, Grid, AppBar, Toolbar, Stack, Card, CardContent, CardHeader, TextField, FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@mui/material';
import Status from '../../models/Status';
import StatusService from '../../services/StatusService';
import Task from '../../models/Task';

interface TaskModalProps {
    open?: boolean;
    value?: Task;
    mode?: 'create' | 'update';
    errors?: {[key: string]: string[]};
    onModalSaveClick?: (task: Task) => void;
    onModalCloseClick?:() => void;
}

const TaskModal : React.FC<TaskModalProps> = ({open, value, mode, errors, onModalSaveClick, onModalCloseClick}) => {
    const  defaultTask = {id: 0, title: "", description: "", statusId: 0};

    const statusService = new StatusService();

    const [task, setTask] = useState<Task>(value ?? defaultTask);
    const [status, setStatus] = useState<Status[]>([]);

    const onSaveClick = () => {
        if(onModalSaveClick){
            if(mode === "update") {
                onModalSaveClick(task);
            } else {
                onModalSaveClick(task);
                setTask(defaultTask);   
            }
        }
    };

    const onCancelClick = () => {
        if(onModalCloseClick){
            onModalCloseClick();
            setTask(defaultTask);
        }
    }

    useEffect(() => {
        statusService.searchAsync('')
                     .then(response => setStatus(response.data));
    },[]);

    useEffect(() => {
        if (value && value !== task) {
            setTask(value);
        }
    }, [value]);

    return (
        <Backdrop open={open ?? false} sx={{backgroundColor:"white"}}>
            <AppBar component="nav" position="absolute" elevation={0} color='transparent' >
                <Container>
                    <Toolbar disableGutters>
                        <Stack direction="row" justifyContent="flex-end" spacing={1} width="100%">
                            <Button variant="outlined" onClick={onCancelClick} sx={{width:100}}>Cancelar</Button>
                            <Button variant="contained" onClick={onSaveClick} sx={{width:100}}>Salvar</Button>
                        </Stack>
                    </Toolbar>
                    <Card variant='outlined'>
                        <CardHeader title={mode === "update" ? "Atualizar tarefa" : "Cadastrar tarefa"}>
                        </CardHeader>
                        <CardContent>
                            <Grid container spacing={3}>
                                <Grid item xs={12} lg={6}>
                                    <TextField label="Titulo" value={task?.title} onChange={(event) => setTask({...task, title: event.target.value})} error={errors && errors["Title"]?.length > 0} helperText={errors && errors["Title"]?.length > 0 && errors["Title"][0]} fullWidth/>
                                </Grid>
                                <Grid item xs={12} lg={6}>
                                    <FormControl error={errors && errors["StatusId"]?.length > 0} fullWidth>
                                        <InputLabel id="demo-simple-select-label">Status</InputLabel>
                                        <Select value={task.statusId} onChange={(event) => setTask({...task, statusId: Number(event.target.value)})}>
                                            <MenuItem value={0}>Selecione</MenuItem>
                                            {
                                                status && status.length > 0 ? status.map(status => <MenuItem key={status.id} value={status.id}>{status.name}</MenuItem>) : []    
                                            }
                                        </Select>
                                        <FormHelperText>{errors && errors["StatusId"]?.length > 0 && errors["StatusId"][0]}</FormHelperText>
                                    </FormControl>
                                </Grid> 
                                <Grid item xs={12}>
                                    <TextField label="Descrição" value={task.description} onChange={(event) =>  setTask({...task, description: event.target.value})} error={errors && errors["Description"]?.length > 0} helperText={errors && errors["Description"]?.length > 0 && errors["Description"][0]} minRows={4} multiline fullWidth/>
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