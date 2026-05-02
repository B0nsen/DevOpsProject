import React from 'react';
import axios from 'axios';

function ConfirmDelete({ i_url, i_id, get, k_value}) {

    const Delete = () => {
        axios.delete(`${i_url}/${k_value}/${i_id}`)
            .then(() => closeConfirmation())
            .then(() => get())
            .catch(error => {
                console.error("Error during axios request", error);
            });
    };

    const closeConfirmation = () => {
        document.getElementById('confirm').style.display = 'none';
    };

    return (
        <div className="confirmation-window" id="confirm">
            <div className="confirmation-body">
                <h2>Confirm delete</h2>
                <div>
                    <button onClick={() => {Delete()}}>Yes</button>
                    <button onClick={() => { closeConfirmation() }}>No</button>
                </div>
            </div>

            
        </div>
    );
}

export default ConfirmDelete;