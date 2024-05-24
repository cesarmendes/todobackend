import { Card, CardContent, IconButton, TableContainer, Table, TableHead, TableBody, TableRow, TableCell, Tooltip, Typography } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

import Task from "../../models/Task";

interface TaskTableProps {
    tasks?: Task[];
    onEditClick?: (task: Task) => void;
    onDeleteClick?: (task: Task) => void;
  }

const TaskTable : React.FC<TaskTableProps> = ({tasks, onEditClick, onDeleteClick}) => {
    const style = {tableCell: {fontWeight: "bold"}};

    return (
        <Card variant="outlined">
            <CardContent>
                <TableContainer>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell variant="head" sx={style.tableCell}>Id</TableCell>
                                <TableCell variant="head" sx={style.tableCell}>Título</TableCell>
                                <TableCell variant="head" sx={style.tableCell}>Status</TableCell>
                                <TableCell variant="head" sx={style.tableCell}>Criado em</TableCell>
                                <TableCell variant="head" sx={style.tableCell}></TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {
                                tasks && tasks.length > 0 ?
                                tasks.map(task => (
                                    <TableRow key={task.id}>
                                        <TableCell>{task.id}</TableCell>
                                        <TableCell>{task.title}</TableCell>
                                        <TableCell>{task.statusId}</TableCell>
                                        <TableCell>{task.description}</TableCell>
                                        <TableCell align="center">
                                            <Tooltip title="Atualizar tarefa" onClick={() => onEditClick && onEditClick(task)}>
                                                <IconButton aria-label="delete" color="primary">
                                                    <EditIcon />
                                                </IconButton>
                                            </Tooltip>
                                            <Tooltip title="Excluir tarefa" onClick={() => onDeleteClick && onDeleteClick(task)}>
                                                <IconButton aria-label="delete" color="primary">
                                                    <DeleteIcon />
                                                </IconButton>
                                            </Tooltip>
                                        </TableCell>
                                    </TableRow>
                                ))
                                :
                                <TableRow>
                                    <TableCell colSpan={5}>
                                        <Typography>Nenhuma tarefa foi encontrada</Typography>
                                    </TableCell>
                                </TableRow>
                            }
                      
                        </TableBody>
                    </Table>
                </TableContainer>
            </CardContent>
        </Card>
    );
};

export default TaskTable;