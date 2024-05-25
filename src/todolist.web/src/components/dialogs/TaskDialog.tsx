import { Button, Dialog, DialogActions, DialogTitle, DialogContent, DialogContentText } from '@mui/material';
import Task from '../../models/Task';

interface TaskDialogProps {
    title?: string;
    description?: string;
    value?: Task;
    btnOk?:string;
    btnCancel?:string;
    onDialogSaveClick?: () => void;
    onDialogCloseClick?:() => void;
}

const TaskDialog : React.FC<TaskDialogProps>= ({title, description, value, btnOk, btnCancel, onDialogSaveClick, onDialogCloseClick}) => {
    return (
        <Dialog open={value !== undefined} onClose={() => onDialogCloseClick && onDialogCloseClick()} aria-labelledby="alert-dialog-title" aria-describedby="alert-dialog-description">
            <DialogTitle>{title}</DialogTitle>
            <DialogContent>
                <DialogContentText>
                    {description}
                </DialogContentText>
            </DialogContent>
            <DialogActions>
                <Button onClick={() => onDialogCloseClick && onDialogCloseClick()}>{btnCancel}</Button>
                <Button onClick={() => onDialogSaveClick && onDialogSaveClick()} variant="contained" autoFocus>{btnOk}</Button>
            </DialogActions>
        </Dialog>
    );
};

export default TaskDialog;