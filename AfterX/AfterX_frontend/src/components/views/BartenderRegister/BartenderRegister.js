import React, { Component } from 'react';
import RegisterPage from '../RegisterPage/RegisterPage';
import Slideshow from '../../utils/Slideshow';
import slide1 from '../slides/slide1.jpg';
import slide2 from '../slides/slide6.jpg';
import slide3 from '../slides/slide3.jfif';
import slide4 from '../slides/slide4.jpg';
import slide5 from '../slides/slide5.jpg';
import './BartenderRegister.css';
import image from '../wb.png';

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter fSize2',
  main: 'flex8 white',
  footer: 'flex1 fCenter',
  floatingLogin: 'floatingLogin',
};

const slides = [slide1, slide2, slide3, slide4, slide5];

class BartenderRegister extends Component {
  render() {
    return (
      <div className={s.container}>
        <div className={s.header}>
          <img className="logoImage" src={image} alt="slika" />
        </div>
        <div className={s.main}>
          <Slideshow slides={slides} />
        </div>

        <div className="floatingRegister">
          <div style={{ marginTop: '-150px' }}>
            <RegisterPage />
          </div>
        </div>
      </div>
    );
  }
}

export default BartenderRegister;
