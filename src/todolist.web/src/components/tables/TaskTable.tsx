import { Card, CardContent, IconButton, TableContainer, Table, TableHead, TableBody, TableRow, TableCell, Tooltip, Typography, Pagination, Skeleton, Stack } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

import Task from "../../models/Task";
import Paginated from "../../models/Paginated";

interface TaskTableProps {
    loading?: boolean;
    paginated?: Paginated<Task>;
    onEditClick?: (task: Task) => void;
    onDeleteClick?: (task: Task) => void;
    onPageChange?: (page: number) => void;
  }

const TaskTable : React.FC<TaskTableProps> = ({loading, paginated, onEditClick, onDeleteClick, onPageChange}) => {
    const style = {table:{marginBottom:3}, tableCell: {fontWeight: "bold"}};

    const handleChange = (event: React.ChangeEvent<unknown>, value: number) => {
        event.preventDefault();

        onPageChange && onPageChange(value);
    };

    return (
        <Card variant="outlined">
            <CardContent>
                <TableContainer>
                    <Table sx={style.table}>
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
                                !loading ?
                                paginated && paginated.items?.length > 0 ?
                                paginated.items.map(task => (
                                    <TableRow key={task.id}>
                                        <TableCell>{task.id}</TableCell>
                                        <TableCell>{task.title}</TableCell>
                                        <TableCell>{task.status}</TableCell>
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
                                :
                                <>
                                    <TableRow>
                                        <TableCell colSpan={5}>
                                            <Skeleton variant="rectangular" height={50}/>
                                        </TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell colSpan={5}>
                                            <Skeleton variant="rectangular" height={50}/>
                                        </TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell colSpan={5}>
                                            <Skeleton variant="rectangular" height={50}/>
                                        </TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell colSpan={5}>
                                            <Skeleton variant="rectangular" height={50}/>
                                        </TableCell>
                                    </TableRow>
                                </>
                            }
                      
                        </TableBody>
                    </Table>
                    {
                        paginated && paginated.items?.length > 0 ?
                        <Stack direction="row" justifyContent="flex-end">
                            <Pagination color="primary" page={paginated?.pageNumber} count={paginated?.totalPages} onChange={handleChange} />
                        </Stack>
                        :
                        null
                    }
                </TableContainer>
            </CardContent>
        </Card>
    );
};

export default TaskTable;