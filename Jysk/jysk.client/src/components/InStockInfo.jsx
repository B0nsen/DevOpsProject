import React from 'react';

const variants = {
    shippingAvailable: { text: 'Delivery', color: 'var(--in-stock-green)' },
    shippingUnavailable: { text: 'Delivery', color: 'var(--in-stock-red)' },
    inStock: { text: 'In stock', color: 'var(--in-stock-green)' },
    notInStock: { text: 'Not available in stores', color: 'var(--in-stock-red)' },
    availableToOrder: { text: 'Can be ordered at a HYGGY store', color: 'var(--in-stock-yellow)' },
};

/**
 * @param {{ type: 'shippingAvailable' | 'shippingUnavailable' | 'inStock' | 'notInStock' | 'availableToOrder' }} props
 */
export default function InStockInfo({ type }) {
    const variant = variants[type];

    if (!variant) return null;

    return (
        <div className='in-stock'>
            <span className='in-stock-icon' style={{ backgroundColor: variant.color }}></span>
            <span className='in-stock-value'>{variant.text}</span>
        </div>
    );
}