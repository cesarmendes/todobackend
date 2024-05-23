import { MouseEventHandler, useEffect, useState } from 'react';
import { Button,  Container, Backdrop, Grid, AppBar, Toolbar, Stack, Card, CardContent, CardHeader, TextField, FormControl, InputLabel, Select, MenuItem, FormHelperText } from '@mui/material';
import Status from '../../models/Status';
import StatusService from '../../services/StatusService';
import TaskService from '../../services/TaskService';
import ValidationError from '../../models/ValidationError';

interface CreateTaskModalProps {
    open?: boolean;
    onCloseClick?: MouseEventHandler<Element>;
}

const CreateTaskModal : React.FC<CreateTaskModalProps> = ({open, onCloseClick}) => {
    const statusService = new StatusService();
    const taskService = new TaskService()

    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [statusId, setStatusId] = useState('0');
    const [status, setStatus] = useState<Status[]>([]);
    const [validation, setValidation] = useState<ValidationError>();

    const onSaveClick = () =>{
        taskService.createAsync({id:0, title: title, description: description, status:'', statusId: parseInt(statusId)})
                   .then(response => console.log(response.data))
                   .catch(error => {
                     if(error.response.status === 400){
                        setValidation(error.response.data);
                     } else if(error.response.status === 409){
                        console.log(error.response.data);
                     }
                   });
    }

    useEffect(() => {
        statusService.searchAsync('')
                     .then(response => setStatus(response.data));
    },[]);

    return (
        <Backdrop open={open ?? false} sx={{backgroundColor:"white"}}>
            <AppBar component="nav" position="absolute" elevation={0} color='transparent' >
                <Container>
                    <Toolbar disableGutters>
                        <Stack direction="row" justifyContent="flex-end" spacing={1} width="100%">
                            <Button variant="outlined" onClick={onCloseClick} sx={{width:100}}>Cancelar</Button>
                            <Button variant="contained" onClick={onSaveClick} sx={{width:100}}>Salvar</Button>
                        </Stack>
                    </Toolbar>
                    <Card variant='outlined'>
                        <CardHeader title="Nova tarefa">
                        </CardHeader>
                        <CardContent>
                            <Grid container spacing={3}>
                                <Grid item xs={12} lg={6}>
                                    <TextField label="Titulo" value={title} onChange={(event) => {setTitle(event.target.value); }} error={validation && validation.errors["Title"].length > 0} helperText={validation && validation.errors["Title"][0]} fullWidth/>
                                </Grid>
                                <Grid item xs={12} lg={6}>
                                    <FormControl error={validation && validation.errors["StatusId"].length > 0} fullWidth>
                                        <InputLabel id="demo-simple-select-label">Status</InputLabel>
                                        <Select value={statusId} onChange={(event) => setStatusId(event.target.value)}>
                                            <MenuItem value={0}>Selecione</MenuItem>
                                            {
                                                status && status.length > 0 ? status.map(status => <MenuItem key={status.id} value={status.id}>{status.name}</MenuItem>) : []    
                                            }
                                        </Select>
                                        <FormHelperText>{validation && validation.errors["StatusId"][0]}</FormHelperText>
                                    </FormControl>
                                </Grid> 
                                <Grid item xs={12}>
                                    <TextField label="Descrição" value={description} onChange={(event) =>  setDescription(event.target.value)} error={validation && validation.errors["Description"].length > 0} helperText={validation &&validation.errors["Description"][0]} minRows={4} multiline fullWidth/>
                                </Grid>   
                            </Grid>
                        </CardContent>
                    </Card>
                </Container>
            </AppBar>
        </Backdrop>
    );
};

export default CreateTaskModal;