import '../styles/components/AdminSideBar.scss';
import React, { useState } from 'react';
import logo from '../assets/icons/logo.png';
import { useNavigate } from 'react-router-dom';

const AdminSideBar = () => {
    const [isOpen, setIsOpen] = useState(false);
    const navigate = useNavigate();

    const handleClick = (e) => {
        const value = e.target.innerText;
        navigate(`/Admin/Panel?value=${encodeURIComponent(value)}`)
        window.location.reload()
    }
        return (
            <div class="sidebar">
                <a href="..">
                    <div>
                        <img className="site-logo" src={logo} alt="Logo" />
                        <p>Main page</p>
                    </div>
                </a>
                <ul>
                    <li>
                        <button onClick={handleClick}>Product</button>
                    </li>
                    <li onClick={() => setIsOpen(!isOpen)} class="clickable">Storages</li>
                    <li className={`nested ${isOpen ? 'open' : ''}`}>
                        <ul>
                            <li>
                                <button onClick={handleClick}>Storage</button>
                            </li>
                            <li>
                                <button onClick={handleClick}>Supply</button>
                            </li>
                            <li>
                                <button onClick={handleClick}>Delivery</button>
                            </li>
                            <li>
                                <button onClick={handleClick}>Cargo</button>
                            </li>
                            <li>
                                <button onClick={handleClick}>WriteOff</button>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <button onClick={handleClick}>Store</button>
                    </li>
                    <li>
                        <button onClick={handleClick}>Employee</button>
                    </li>
                    <li>
                        <button onClick={handleClick}>Client</button>
                    </li>
                    <li>
                        <button onClick={handleClick}>Order</button>
                    </li>
                    <li>
                        <button onClick={handleClick}>Review</button>
                    </li>
                    <li>
                        <button onClick={handleClick}>Manufacturer</button>
                    </li>
                    <li>
                        <button onClick={handleClick}>Category</button>
                    </li>
                    <li>
                        <button onClick={handleClick}>WorkHours</button>
                    </li>
                </ul>
                <p class="leave">Log-Out</p>
            </div>
        );
};
export default AdminSideBar;