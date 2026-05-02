import '../styles/pages/Admin.scss';
import React from 'react';

const CreateButton = () => {
    const createWindow = () => {

        document.getElementById('data').style.display = 'flex';
        document.getElementById('create').style.display = 'inline';
        document.getElementById('edit').style.display = 'none';
    }

    return (
        <div>
            <button onClick={() => createWindow()} class="create">Create</button>
        </div>
    );
};

export default CreateButton;
