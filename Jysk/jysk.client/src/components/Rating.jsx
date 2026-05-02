import React from 'react';
import star from '../assets/icons/star.svg';
import starFilled from '../assets/icons/star-filled.svg';

export default function Rating({ value = 0, max = 5 }) {
    const stars = Array.from({ length: max }, (_, i) => (
        <img
            key={i}
            src={i < value ? starFilled : star}
            alt="Star"
        />
    ));

    return <div className="rating">{stars}</div>;
}