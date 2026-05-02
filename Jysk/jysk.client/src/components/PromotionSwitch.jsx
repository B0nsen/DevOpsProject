import React from 'react';
import Switch from 'react-switch';

export default function PromotionSwitch({ checked, onChange }) {
    return (
        <Switch 
            onChange={onChange}
            checked={checked}
            onColor="#00AAAD"
            offColor="#E0E0E0"
            onHandleColor="#ffffff"
            offHandleColor="#717171"
            handleDiameter={16}
            uncheckedIcon={false}
            checkedIcon={false}
            height={22}
            width={48}
            className="react-switch"
            id="material-switch"
        />
    );
}
