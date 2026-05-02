import React from 'react';

function AdminInput({ i_key, value, i_func }) {
    var r_key = i_key.charAt(0).toUpperCase() + i_key.slice(1)
    return (
        <div className="admin-field">
            <label htmlFor={i_key}>{r_key}: </label>
            <input id={i_key} type="text" value={value} name={r_key} onChange={i_func}></input>
        </div>

    );
}

export default AdminInput;

