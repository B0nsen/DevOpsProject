import React, { useEffect, useState } from 'react';
import axios from 'axios';
import CreateButton from '../components/CreateButton';
import ConfirmDelete from '../components/ConfirmDelete'
import FormButtons from '../components/FormButtons'
import { useLocation } from 'react-router-dom';
import AdminForm from '../components/AdminForm'
import AdminTable from '../components/AdminTable'


function AdminTest() {
    const { search } = useLocation();
    const params = new URLSearchParams(search);
    const k_value = params.get("value");
    const [list, setList] = useState([]);
    const [formData, setFormData] = useState({
        Supply: {
            ProductId: '',
            Count: '',
        },
        Manufacturer: {
            Name: ''
        },
        Cargo: {
            ProductId: '',
            StorageToId: '',
            StorageFromId: '',
            Count: '',
            EmployeeId: '',
        },
        Category: {
            Name: '',
        },
        Client: {
            UserId: '',
            Address: '',
            Sum: '',
        },
        Delivery: {
            ManufacturerId: '',
            StorageId: '',
            Date: '',
            Comment: '',
            Status: false,
            Sum: '',
        },
        Employee: {
            UserId: '',
            Position: '',
            Comment: '',
        },
        Order: {
            ProductId: '',
            Count: '',
            Productionprice: '',
            Finalprice: '',
            Markup: '',
            UserId: '',
        },
        Product: {
            Name: '',
            Description: '',
            Price: '',
            Rating: '',
            Delivery: false,
            ManufacturerId: '',
            CategoryId: '',
            Discount: '',
        },
        Review: {
            Rating: '',
            Description: '',
            ProductId: '',
        },
        Storage: {
            Name: '',
            Address: '',
            Sum: '',
        },
        Store: {
            Name: '',
            Housenumber: '',
            Totalproductsum: '',
            StorageId: '',
            WorkHoursId: '',
        },
        WorkHours: {
            Day: '',
            Start: '',
            End: '',
        },
        WriteOff: {
            Date: '',
            EmployeeId: '',
            StorageId: '',
            ProductId: '',
            Reason: '',
            Sum: '',
        }
    });

    const [options, setOptions] = useState({
        Product: useState([]),
        Storage: useState([]),
        Employee: useState([]),
        User: useState([]),
        Manufacturer: useState([]),
        WorkHours: useState([]),
        Category: useState([]),
    });

    const [id, setId] = useState({
        Id: '',
    })

    let url = "https://localhost:7196/api"

    const InputChange = (e) => {
        const { name, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [k_value]: {
                ...prev[k_value],
                [name]: value
            }
        }));
    };

    const GetAll = () => {
        axios.get(`${url}/${k_value}`)
            .then(response => setList(response.data))
            .catch(error => {
                console.error("Error during Supply axios request", error);
            });
    };

    const GetId = (id) => {
        axios.get(`${url}/${k_value}/${id}`)
            .then((response) => {
                const data = response.data;
                for (const key in data) {
                    const input = document.getElementById(`${key}`);
                    if (input) {
                        input.value = data[key];
                        setFormData(prev => ({
                            ...prev,
                            [k_value]: {
                                ...prev[k_value],
                                [key.charAt(0).toUpperCase() + key.slice(1)]: data[key]
                            }
                        }));
                    }
                }
            })
            .catch(error => {
                console.error("Error during Supply axios request", error);
            });
    };

    const openConfirmation = (id) => {
        setId({
            Id: id
        });
        document.getElementById('confirm').style.display = 'flex';
    };


    const editWindow = (id) => {
        setId({
            Id: id
        });
        GetId(id);
        document.getElementById('data').style.display = 'flex';
        document.getElementById('create').style.display = 'none';
        document.getElementById('edit').style.display = 'inline';
    };

    const closeWindow = () => {
        const inputs = document.querySelectorAll("#data input");
        inputs.forEach(input => input.value = "");
        const selectors = document.querySelectorAll("#data select");
        selectors.forEach(selector => selector.value = 0);
        for (var key in formData[k_value]) {
            setFormData(prev => ({
                ...prev,
                [k_value]: {
                    ...prev[k_value],
                    [key]: ''
                }
            }));
        }
        document.getElementById('data').style.display = 'none';
    };


    const createFunc = () => {
        setFormData(prev => ({
            ...prev,
            [k_value]:
            {
                ...prev[k_value],
                Id: 0,
            }
        }))
        axios.post(`${url}/${k_value}`, formData[k_value])
            .then(() => GetAll())
            .then(() => closeWindow())
            .catch(error => {
                console.error("Error during axios request", error);
            });
    };

    
    const editFunc = () => {
        setFormData(prev => ({
            ...prev,
            [k_value]:
            {
                ...prev[k_value],
                Id: id.Id,
            }
        }))
        axios.put(`${url}/${k_value}`, formData[k_value])
            .then(() => GetAll())
            .then(() => closeWindow())
            .catch(error => {
                console.error("Error during Supply axios request", error);
            });
    };

    const GetAllOptions = (e) => {
        axios.get(`${url}/${e}`)
            .then(response => setOptions(prev => ({
                ...prev,
                [e]: response.data
            })))
            .catch(error => {
                console.error("Error during axios request", error);
            });
    };


    useEffect(() => {
        GetAll();
        for (var key in options) {
            GetAllOptions(key);
        }
    }, []);

    return (
        <div>
            <div className="admin-header">
                <h1>{k_value}</h1>
                <CreateButton></CreateButton>
            </div>
            <div>
                <AdminTable list={list} e_func={editWindow} o_func={openConfirmation} />
            </div>
            <ConfirmDelete i_url={url} i_id={id.Id} get={GetAll} k_value={k_value} />
            <div className="data-window" id="data">
                <div className="data-body">
                    <h2>Enter data</h2>
                    <AdminForm i_func={InputChange} options={options} formData={formData[k_value]} sfd={setFormData} />
                    <FormButtons e_func={editFunc} c_func={createFunc} cl_func={closeWindow} />
                </div>
            </div>
        </div>
    );
}

export default AdminTest;