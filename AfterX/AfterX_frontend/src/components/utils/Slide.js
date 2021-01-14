import React, { memo } from 'react';
import PropType from 'prop-types';

const s = {
  container: 'abs fullW fullH',
  slideImage: 'fullH fullW imgCover',
};

const Slide = ({ position, transition, image }) => (
  <div className={`${s.container} ${position} ${transition}`}>
    <img src={image} className={s.slideImage} alt="slide" />
  </div>
);

Slide.propTypes = {
  position: PropType.any,
  transition: PropType.any,
  image: PropType.any,
};

export default memo(Slide);
