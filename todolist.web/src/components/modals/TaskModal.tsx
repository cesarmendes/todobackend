import { useEffect, useState } from 'react';
import { Button,  Container, Backdrop, Grid, AppBar, Toolbar, Stack, Card, CardContent, CardHeader, TextField, FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@mui/material';
import { ptBR } from '@mui/x-date-pickers/locales';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DatePicker } from '@mui/x-date-pickers/DatePicker'
import Status from '../../models/Status';
import Task from '../../models/Task';
import dayjs from 'dayjs';


interface TaskModalProps {
    open?: boolean;
    value?: Task;
    mode?: 'create' | 'update';
    status?: Status[];
    errors?: {[key: string]: string[]};
    onModalSaveClick?: (task: Task) => void;
    onModalCloseClick?:() => void;
}

const TaskModal : React.FC<TaskModalProps> = ({open, value, mode, status, errors, onModalSaveClick, onModalCloseClick}) => {
    const  defaultTask = {id: 0, title: "", description: "", statusId: 0, startDate: new Date(), targetDate: new Date()};

    const [task, setTask] = useState<Task>(value ?? defaultTask);

    const onSaveClick = () => {
        if(onModalSaveClick){
            onModalSaveClick(task);

            if(mode !== "update") {
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
                                <Grid item xs={12} lg={6}>
                                    <LocalizationProvider localeText={ptBR.components.MuiLocalizationProvider.defaultProps.localeText} dateAdapter={AdapterDayjs}>
                                        <DatePicker label="Data de início" value={dayjs(task.startDate)} onChange={(newValue) => setTask({...task, startDate: dayjs(newValue).toDate()})} format='DD/MM/YYYY' sx={{width:'100%'}}/>
                                    </LocalizationProvider>
                                </Grid>
                                <Grid item xs={12} lg={6}>
                                    <FormControl error={errors && errors["TargetDate"]?.length > 0} fullWidth>
                                        <LocalizationProvider localeText={ptBR.components.MuiLocalizationProvider.defaultProps.localeText} dateAdapter={AdapterDayjs}>
                                            <DatePicker label="Data de entrega" minDate={dayjs(task.startDate)} value={dayjs(task.targetDate)} onChange={(newValue) => setTask({...task, targetDate: dayjs(newValue).toDate()})} format='DD/MM/YYYY' sx={{width:'100%'}}/>
                                        </LocalizationProvider>
                                        <FormHelperText>{errors && errors["TargetDate"]?.length > 0 && errors["TargetDate"][0]}</FormHelperText>
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