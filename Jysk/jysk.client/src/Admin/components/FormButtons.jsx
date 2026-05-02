import React from 'react';

function FormButtons({ e_func, c_func, cl_func }) {
    return (
        <div>
            <button onClick={() => { c_func() } } id="create">Confirm</button>
            <button onClick={() => { e_func() }} id="edit">Confirm</button>
            <button onClick={() => { cl_func() }}>Cancel</button>
        </div>
    );
}

export default FormButtons;