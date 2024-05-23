import CssBaseline from '@mui/material/CssBaseline';
import { BrowserRouter } from 'react-router-dom';

import Header from './components/headers/Header';
import AppRouter from './AppRouter';

function App() {
    return (
        <BrowserRouter>
            <CssBaseline />
            <Header />
            <AppRouter />
        </BrowserRouter>
    );
}

export default App;
