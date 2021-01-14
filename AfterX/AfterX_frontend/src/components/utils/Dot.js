import React, { memo } from 'react';
import PropType from 'prop-types';
import Spacer from './Spacer';
//= ==========================================
// DOT FUNCTIONAL COMPONENT
//= ==========================================
const Dot = ({ slideId, dotId }) => (
  <div className="row">
    <Spacer w={5} />
    <div className={`dot ${slideId === dotId ? 'white' : 'white50'}`} />
    <Spacer w={5} />
  </div>
);
Dot.propTypes = {
  slideId: PropType.any,
  dotId: PropType.any,
};
export default memo(Dot);
