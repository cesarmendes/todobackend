import { Route, Routes } from 'react-router-dom';
import Home from './views/Home';
import NotFound from './views/NotFound';


function AppRouter() {
    return (
        <Routes>
            <Route path="/" element={<Home />} />
            {/*<Route path="/login" element={<Login />} />*/}
            <Route path="*" element={<NotFound />} />
        </Routes>
    );
}

export default AppRouter;