import '../styles/components/Footer.scss';
import gpayIcon from '../assets/icons/gpay.png';
import mastercardIcon from '../assets/icons/mastercard.png';
import visaIcon from '../assets/icons/visa.png';
import facebookIcon from '../assets/icons/facebook.svg';
import telegramIcon from '../assets/icons/telegram.svg';
import instagramIcon from '../assets/icons/instagram.svg';
import youtubeIcon from '../assets/icons/youtube.svg';
export default function Footer() {
    return (
        <div>
            <footer className="site-footer">
                <div className="footer-container row">
                    <div className="col-6 col-md-3 mb-4">
                        <h3>Product Categories</h3>
                        <p>Bedroom</p>
                        <p>Bathroom</p>
                        <p>Office</p>
                        <p>Living Room</p>
                        <p>Kitchen and Dining</p>
                        <p>Storage</p>
                        <p>For Windows</p>
                        <p>For Garden</p>
                        <p>For Home</p>
                        <p>All Categories</p>
                    </div>
                    <div className="col-6 col-md-3 mb-4">
                        <h3>Information</h3>
                        <p>Feedback</p>
                        <p>Stores and Opening Hours</p>
                        <p>Terms and Conditions</p>
                        <p>Delivery</p>
                        <p>Privacy Policy</p>
                    </div>
                    <div className="col-6 col-md-3 mb-4">
                        <h3>Hyggy</h3>
                        <p>About Us</p>
                        <p>Careers at Hyggy</p>
                        <p>Subscribe to Newsletter</p>
                        <p>Blog</p>
                        <p>B2B</p>
                        <p>Useful Links</p>
                    </div>
                    <div className="col-6 col-md-3 mb-4">
                        <h3>Head Office</h3>
                        <p>LLC ""</p>
                        <p>City ()</p>
                        <p>Street ()</p>
                        <p>123456</p>
                        <h3>HYGGY B2B</h3>
                        <p>Phone: +380123456789</p>
                        <p>Email: b2b@hyggy.com</p>
                        <p>Contact Us</p>
                        <h3>Feedback:</h3>
                        <p>email@hyggy.com</p>
                        <p>Phone: +380123456789 B2B</p>
                        <p>Contact Us</p>
                    </div>
                    <div className="col-12 col-sm-6 payment-options">
                        <img src={gpayIcon} alt="Google Pay" />
                        <img src={mastercardIcon} alt="Mastercard" />
                        <img src={visaIcon} alt="Visa" />
                    </div>
                    <div className="col-12 col-sm-6 social">
                        <img src={facebookIcon} alt="Facebook" />
                        <img src={telegramIcon} alt="Telegram" />
                        <img src={instagramIcon} alt="Instagram" />
                        <img src={youtubeIcon} alt="YouTube" />
                    </div>
                </div>
            </footer>
        </div>
    );
}
