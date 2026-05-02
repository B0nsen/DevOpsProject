import React from 'react';
import AdminSelect from '../components/AdminSelect';
import AdminInput from '../components/AdminInput';
import StatusComponent from '../components/StatusComponent'

function AdminForm({ formData, i_func, options, sfd}) {
    var Form = [];
    const MapForm = () => {
        var r_key;
        for (const key in formData) {
            if (typeof formData[key] === 'boolean')
            {
                //Form.push(<StatusComponent formData={formData} setFormData={sfd} key={key} />)
            }
            else if (key != "Id" && key.includes("Id")) {
                r_key = key;
                Form.push(<AdminSelect i_key={r_key} i_arr={options} i_func={i_func} />)
            }
            else if (key != "Id") {
                r_key = key.toLowerCase();
                Form.push(<AdminInput i_key={r_key} value={formData[key]} i_func={i_func} />)
            }

            }
        }

    return (
        <div>
            {MapForm()}
            {Form}
        </div>
    );
}
export default AdminForm;