import React from 'react';
import classes from '../Input/Input.css'

export const Input = (props) => {
    let inputElement = null;

    switch(props.inputType) {
        case('input'):
            inputElement = <input className={classes.InputElement} {...props} />
        case('textarea'):
            inputElement = <textarea className={classes.InputElement} {...props} />
        case('select'):
            inputElement = <select className={classes.InputElement} ></select>
        default:
            inputElement = <input className={classes.InputElement} {...props} />
    }


    return (
    <div className={classes.Input}>
        <label className={classes.Label}>{props.label}</label>
        {inputElement}
        </div>);
    
};