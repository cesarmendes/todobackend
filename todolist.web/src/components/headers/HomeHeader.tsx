import { Button, Stack, Typography } from "@mui/material";
import { MouseEventHandler } from "react";

interface HomeHeaderProps {
    onButtonClick?: MouseEventHandler<Element>;
  }

const HomeHeader : React.FC<HomeHeaderProps> = ({ onButtonClick }) => {
    return (
        <Stack direction="row" justifyContent="space-between" mt={5} mb={3}>
            <Typography variant="h4">Minhas tarefas</Typography>
            <Button variant="contained" onClick={onButtonClick}>Adicionar</Button>
        </Stack>
    );
};

export default HomeHeader;