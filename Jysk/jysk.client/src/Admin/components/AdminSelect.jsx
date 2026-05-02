import React from 'react';

const AdminSelect = ({ i_key, i_arr, i_func }) => {
    var ur_key = i_key.charAt(0).toLowerCase() + i_key.slice(1);
    var key = i_key.slice(0, i_key.length - 2);
    if (key.includes("Storage")) {
        key = "Storage";
    }
    return (
        <div className="admin-field">
            <label htmlFor={ur_key }>{i_key}: </label>
            <select onChange={i_func} name={i_key} id={ur_key}>
                <option value=""></option>
                {i_arr[key].map(option => (
                    <option key={option.id} value={option.id}>{option.name}</option>
                ))}
            </select>
        </div>
    );
}

export default AdminSelect;