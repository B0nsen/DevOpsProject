import React from 'react';
import PropTypes from 'prop-types';

const stickerVariants = {
    discount: (discountValue) => ({ 
      text: `-${discountValue}%`, 
      color: 'red' 
    }),
    newItem: { text: 'New', color: 'green' },
    greatOffer: { text: 'A great offer', color: 'teal' },
};

const Sticker = ({ type, discountValue }) => {
    const { text, color } = type === 'discount' 
      ? stickerVariants.discount(discountValue) 
      : stickerVariants[type] || stickerVariants.discount(40);
  
    return (
      <span className={`sticker ${color}`}>
        {text}
      </span>
    );
  };
  
  Sticker.propTypes = {
    type: PropTypes.oneOf(['discount', 'newItem', 'greatOffer']).isRequired,
    discountValue: PropTypes.number,
  };
  
  export default Sticker;