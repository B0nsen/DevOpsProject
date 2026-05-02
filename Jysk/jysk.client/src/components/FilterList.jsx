import React, { useState } from 'react';
import '../styles/components/FilterList.scss';

import BodySection from "../components/BodySection";
import FilterButton from '../components/FilterButton';
import PromotionSwitch from '../components/PromotionSwitch';

export default function FilterList() {
    const [checked, setChecked] = useState(false);

    const handleChange = (nextChecked) => {
        setChecked(nextChecked);
    };
    return(
        <div>
            <BodySection>
                <div className='filter-list'>
                    <div className='flex-row gap-medium'>
                    <div className='flex-row gap-medium'>
                        <FilterButton text="Price (GBP)" onClick={() => console.log('Price')} hideOnMobile />
                        <FilterButton text="Colour" onClick={() => console.log('Colour')} hideOnMobile />
                        <FilterButton text="Brand" onClick={() => console.log('Brand')} hideOnMobile />
                        <FilterButton text="Sort" onClick={() => console.log('Sort')} />
                        <FilterButton text="All filters" withIcon={false} onClick={() => console.log('All filters')} />
                    </div>
                    </div>
                    <div className='flex-row gap-medium cursor-pointer'>
                        <p>Products on promotion</p>
                        <PromotionSwitch checked={checked} onChange={handleChange} />
                    </div>
                </div>
            </BodySection>
        </div>
    )

}