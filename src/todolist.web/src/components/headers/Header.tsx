import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { Link } from 'react-router-dom';
import { Container } from '@mui/material';

const Header = () => {
    return (
        <header>
            <AppBar component="nav" position="relative">
                <Container>
                    <Toolbar disableGutters>
                        <Button color="inherit" component={Link} to="/">
                            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                                Todo List
                            </Typography>
                        </Button>
                    </Toolbar>
                </Container>
            </AppBar>
        </header>
    );
};

export default Header;