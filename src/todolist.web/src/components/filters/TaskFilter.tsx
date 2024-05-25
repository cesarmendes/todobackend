import { useState } from "react";
import { Button, Card, CardContent, IconButton, InputAdornment, Stack, TextField } from "@mui/material";
import ClearIcon from '@mui/icons-material/Clear';

interface TaskFilterProps {
    onSearchClick?: (name: string) => void;
    onClearClick?: () => void;
}

const TaskFilter : React.FC<TaskFilterProps> = ({onSearchClick, onClearClick}) => {
    const [name, setName] = useState('');
    
    const style = {button:{width:250},card:{marginBottom:3}};

    const onClick = () => {
        setName('');
        onClearClick && onClearClick();
    }

    const onChange = (event : React.ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);    
    }

    return (
        <Card variant='outlined' sx={style.card}>
            <CardContent>
                <Stack direction="row" spacing={3} padding={3}>
                    <TextField label="Pesquisar" placeholder="Qual o nome da tarefa" variant="standard" size='small' value={name} onChange={onChange} fullWidth InputProps={{endAdornment: name.length > 0 ? <InputAdornment position="end"><IconButton onClick={onClick}><ClearIcon/></IconButton></InputAdornment> : null }}/>
                    <Button variant='outlined' size="small" onClick={() => onSearchClick && onSearchClick(name)} sx={style.button}>Pesquisar</Button>
                </Stack>
            </CardContent>
        </Card>
    );
};

export default TaskFilter;