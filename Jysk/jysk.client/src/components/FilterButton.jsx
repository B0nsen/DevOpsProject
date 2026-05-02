import React from 'react';
import arrowDownIcon from '../assets/icons/arrow-down.svg'; 
import '../styles/components/FilterList.scss'; 

export default function FilterButton({ text, withIcon = true, onClick, hideOnMobile = false }) {
    return (
        <button 
            type="button" 
            className={`filter-list__button ${hideOnMobile ? 'hide-on-mobile' : ''}`} 
            onClick={onClick}
        >
            {text}
            {withIcon && <img src={arrowDownIcon} alt="Arrow down" />}
        </button>
    );
}