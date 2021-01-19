import React, { Component } from 'react';
import './BartenderLogin.css';
import Slideshow from '../../utils/Slideshow';
import slide1 from '../slides/slide1.jpg';
import slide2 from '../slides/slide6.jpg';
import slide3 from '../slides/slide3.jfif';
import slide4 from '../slides/slide4.jpg';
import slide5 from '../slides/slide5.jpg';
import LoginPage from '../LoginPage/LoginPage';
import image from '../wb.png';

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter fSize2',
  main: 'flex8 white',
  footer: 'flex1 fCenter',
  floatingLogin: 'floatingLogin',
};

const slides = [slide1, slide2, slide3, slide4, slide5];

class BartenderLogin extends Component {
  render() {
    return (
      <div style={{overflowX: "hidden", overflowY: "hidden"}} className={s.container}>
        <div className={s.header}>
          <img className="logoImage" src={image} alt="Slika" />
        </div>
        <div className={s.main}>
          <Slideshow slides={slides} />
        </div>
        <div className="floatingLogin">
          <div style={{ marginTop: '-200px' }}>
            <LoginPage />
          </div>
        </div>
      </div>
    );
  }
}

export default BartenderLogin;
