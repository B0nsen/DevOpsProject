import Header from "../components/Header";
import Footer from "../components/Footer";
import Prefooter from "../components/Prefooter";

import React from 'react';
import { Outlet } from 'react-router-dom';

function AppLayout() {
    return (
        <div className="layout-wrapper">
            <Header />
            <main className="main-content">
                <Outlet />
            </main>
            <Prefooter />
            <Footer />
        </div>

    );
}
export default AppLayout;
