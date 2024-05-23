import { useEffect, useState } from 'react';
import { Container } from '@mui/material';

import TaskTable from '../components/tables/TaskTable';
import HomeHeader from '../components/headers/HomeHeader';
import TaskFilter from '../components/filters/TaskFilter';
import Task from '../models/Task';
import TaskService from '../services/TaskService';
import CreateTaskModal from '../components/modals/CreateTaskModal';

const Home = () => {
    const taskService = new TaskService();
    
    const [open, setOpen] = useState<boolean>(false);
    const [tasks, setTasks] = useState<Task[]>([]);

    const onSearchClick = async (name: string) => {
        const response = await taskService.searchAsync(name);
        setTasks(response.data);
    };
    const onEditClick = (id: number) => {alert("Edit id: " + id);}
    const onDeleteClick = (id: number) => {alert("Delete id: " + id);}

    useEffect(() => {
        taskService.searchAsync('')
                   .then(response => setTasks(response.data));
    }, []);

    return (
        <Container>
            <HomeHeader onButtonClick={()=> setOpen(true)}/>
            <hr />
            <TaskFilter onSearchClick={onSearchClick}/>
            <TaskTable tasks={tasks} onDeleteClick={onDeleteClick} onEditClick={onEditClick}/>
            <CreateTaskModal open={open} onCloseClick={() => {setOpen(false)}}/>
        </Container>
    );
};

export default Home;