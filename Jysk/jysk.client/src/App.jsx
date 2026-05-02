import { Routes, Route } from 'react-router-dom';
import AppLayout from './layouts/AppLayout';
import Home from './pages/Home';

import Admin from './Admin/pages/Admin';
import Search from './pages/Search';
import Panel from './Admin/pages/Panel'

import './App.scss';
import AdminLayout from './Admin/layouts/AdminLayout';

function App() {
    return (
        <div>
            <Routes>
                <Route element={<AppLayout />}>
                    <Route path="/" element={<Home />} />
                    <Route path="/search" element={<Search />} />

                </Route>
                <Route element={<AdminLayout />}>
                    <Route path="/Admin" element={<Admin />}></Route>
                    <Route path="/Admin/Panel" element={<Panel />}></Route>
                </Route>
            </Routes>
        </div>
    );
}
export default App;
