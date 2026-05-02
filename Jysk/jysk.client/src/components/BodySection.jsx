import React from 'react';
import '../styles/components/BodySection.scss';

export default function BodySection({ children, bgWhite = false, noBorder = false }) {
    const classNames = [
        'body-section',
        bgWhite ? 'bg-white' : '',
        !bgWhite && !noBorder ? 'border-bottom' : '',
    ].join(' ').trim();

    return (
        <div className={classNames}>
            <div className="section-container">
                {children}
            </div>
        </div>
    );
}
