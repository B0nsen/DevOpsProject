import React from 'react';

function StatusComponent({ formData, setFormData, key }) {
    return (
        <div className="admin-field">
            <label htmlFor="status">Status: </label>
            <input id="status" type="checkbox" checked={formData[key]} name={key} onChange={(e) => setFormData({ ...formData, [key]: e.target.checked })}></input>
        </div>
    );
}
export default StatusComponent;