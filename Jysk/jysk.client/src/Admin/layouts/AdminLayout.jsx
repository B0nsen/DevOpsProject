import AdminSideBar from "../components/AdminSideBar"
import React from 'react';
import { Outlet } from 'react-router-dom';
import '../styles/components/AdminLayout.scss';

function AdminLayout() {
    return (
        <div className="admin-layout-wrapper">
            <AdminSideBar></AdminSideBar>
            <main className="admin-main-content">
            <Outlet />
            </main>
        </div>
    );
}
export default AdminLayout;