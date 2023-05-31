import React, { useState } from 'react';
import { Button } from '@mui/material';
import SelectForFilter from '../../../../components/SelectForFilter/SelectForFilter';
import './Dayang.scss';

const Dayangs = () => {
  const [dayangs, setDayangs] = useState(test);
  const [judges, setJudges] = useState(judgesTest);
  return (
    <div className='dayang-wrapper'>
      <Button variant='contained' color='inherit'>
        Додати даянг
      </Button>
      {dayangs.map(el => (
        <div className='box' key={el.id}>
          <p>Даянг №{el.id}</p>
          <div className='judges'>
            <div className='judge-item'>
              <p>Боковий №1</p>
              <SelectForFilter label='Суддя' items={judges} />
            </div>
          </div>
        </div>
      ))}
    </div>
  );
};

export { Dayangs };

const judgesTest = ['Прокопенко Ю.С.', 'Прокопенко Ю.С.', 'Прокопенко Ю.С.'];

const test = [
  {
    id: 1,
    side1: '',
    side2: '',
    side3: '',
    side4: '',
    referree: '',
    vicehead: '',
    head: '',
    spare: '',
  },
  {
    id: 2,
    side1: '',
    side2: '',
    side3: '',
    side4: '',
    referree: '',
    vicehead: '',
    head: '',
    spare: '',
  },
  {
    id: 3,
    side1: '',
    side2: '',
    side3: '',
    side4: '',
    referree: '',
    vicehead: '',
    head: '',
    spare: '',
  },
  {
    id: 4,
    side1: '',
    side2: '',
    side3: '',
    side4: '',
    referree: '',
    vicehead: '',
    head: '',
    spare: '',
  },
];
