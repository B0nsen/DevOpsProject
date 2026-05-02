import React from 'react';
import Sticker from './Sticker';
import Rating from './Rating';
import InStockInfo from './InStockInfo';
import wishlist from '../assets/icons/heart.svg';
import chair from '../assets/img/chair.png';
import '../styles/components/ProductCard.scss';

const ProductCard = ({ index }) => {
  return (
    <div className='product-card'>
      <div className='img-container'>
        <div className='overlay-container'>
          <div className='wishlist-icon-container'>
            <img className='wishlist-icon' src={wishlist} alt={`Wishlist`} />
          </div>
          <div className='stickers'>
            <Sticker type="discount" discountValue={80} />
            <Sticker type="newItem" />
            <Sticker type="greatOffer" />
          </div>
        </div>
        <img className='product-img' src={chair} alt={`Product ${index}`} />
      </div>
      <div className='desc-container'>
        <p className='product-name'>BISTRUP ({index + 1})</p>
        <p className='product-desc'>BISTRUP Dining Chair, Olive/Door Oak</p>

        <Rating value={2} />

        <p className='price'>60$<span>/each</span></p>
        <p className='old-price'>100$<span>/each</span></p>

        <InStockInfo type="shippingUnavailable" />
        <InStockInfo type="inStock" />
      </div>
    </div>
  );
};

export default ProductCard;