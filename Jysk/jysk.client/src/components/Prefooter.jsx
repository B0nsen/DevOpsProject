import '../styles/components/Prefooter.scss';
import BodySection from "../components/BodySection";

import overviewIcon1 from '../assets/icons/overview-icon1.svg';
import overviewIcon2 from '../assets/icons/overview-icon2.svg';
import overviewIcon3 from '../assets/icons/overview-icon3.svg';

export default function Prefooter(){
    return(
        <div>
            <BodySection bgWhite>
                <div className="overview">
                    <div className="overview-container row flex-wrap justify-content-center">
                        <div className="overview-box col-6 col-md-4 mb-4 text-center ">
                                <img src={overviewIcon1} alt="Overview 1" />
                                <p>A wide variety of modern solutions for decorating and furnishing both interior and exterior spaces.</p>
                        </div>
                        <div className="overview-box col-6 col-md-4 mb-4 text-center">
                                <img src={overviewIcon2} alt="Overview 2" />
                                <p>Our style is reminiscent of Scandinavian, but we go beyond a single direction, offering versatile and functional options that cater to various tastes.</p>
                        </div>
                        <div className="overview-box col-6 col-md-4 mb-4 text-center mt-3 mt-md-0 mx-md-auto">
                                <img src={overviewIcon3} alt="Overview 3" />
                                <p>We cater to different categories of customers, offering products in a range from mid-low to mid-high prices.</p>
                        </div>
                    </div>
                </div>
            </BodySection>
            <BodySection>
                <div className='mailing'>
                    <h2>Subscribe to our newsletter and get a free shipping code for your first order!</h2>
                    <p>Sign up for our newsletter and get a bonus! 10% off your first order, exclusive offers, and early access to sales. Enter your email below and start enjoying the benefits!</p>
                    <div>
                        <input
                            className="input-name"
                            type="text"
                            placeholder="Name"
                        />
                        <input
                            className="input-email"
                            type="text"
                            placeholder="Email"
                        />
                        <button>Share</button>
                    </div>
                </div>
            </BodySection>
        </div>
    )
}