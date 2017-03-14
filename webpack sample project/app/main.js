import React from 'react';
import {render} from 'react-dom';
import Greeter from './greet.js';
import './main.css';

render(React.createElement(Greeter), document.getElementById('root'));