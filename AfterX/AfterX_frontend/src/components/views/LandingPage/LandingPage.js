import './LandingPage.css';
import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import Slideshow from '../../utils/Slideshow';
import slide1 from '../slides/slide1.jpg';
import slide2 from '../slides/slide6.jpg';
import slide3 from '../slides/slide3.jfif';
import slide4 from '../slides/slide4.jpg';
import slide5 from '../slides/slide5.jpg';
import image from '../wb.png';

const s = {
  container: 'screenW screenH dGray col',
  header: 'flex1 fCenter fSize2',
  main: 'flex8 white',
  footer: 'flex1 fCenter',
  floatingLogin: 'floatingLogin',
};

const slides = [slide1, slide2, slide3, slide4, slide5];

class LandingPage extends Component {
  render() {
    return (
      <div className={s.container}>
        <div className={s.header}>
          <img className="logoImage" src={image} alt="Slika" />
        </div>
        <div className={s.main}>
          <Slideshow slides={slides} />
          <div className="buttons">
            <Button
              style={{
                fontSize: '25px',
                fontFamily: 'Impact, Charcoal, sans-serif',
                backgroundColor: 'red',
              }}
              href="/login"
              variant="contained"
              color="primary"
            >
              I am a customer
            </Button>
            <div className="divider" />
            <Button
              style={{
                fontSize: '25px',
                fontFamily: 'Impact, Charcoal, sans-serif',
              }}
              href="/login"
              variant="contained"
              color="primary"
            >
              I am a bartender
            </Button>
          </div>
        </div>
      </div>
    );
  }
}

export default LandingPage;
