import { Button, Card, CardContent, Stack, Typography } from "@mui/material";
import { MouseEventHandler } from "react";

interface HomeHeaderProps {
    onButtonClick?: MouseEventHandler<Element>;
  }

const HomeHeader : React.FC<HomeHeaderProps> = ({ onButtonClick }) => {
    const style = {card:{marginTop:3, marginBottom:3}};

    return (
        <Card variant="outlined" sx={style.card}>
            <CardContent>
                <Stack direction="row" justifyContent="space-between" p={3} pt={2} pb={2}>
                    <Typography variant="h4">Minhas tarefas</Typography>
                    <Button variant="contained" onClick={onButtonClick}>Adicionar tarefa</Button>
                </Stack>
            </CardContent>
        </Card>
    );
};

export default HomeHeader;