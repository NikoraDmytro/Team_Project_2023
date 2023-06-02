import { Tab, Tabs } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { Link, Outlet, useLocation, useNavigate } from 'react-router-dom';
import './Competition.scss';

interface TabLabel {
  label: string;
  link: string;
}

const Competition = () => {
  const tabLabels: TabLabel[] = [
    { label: 'Учасники', link: 'competitors' },
    { label: 'Судді', link: 'judges' },
    { label: 'Даянги', link: 'dayangs' },
    { label: 'Пулі', link: 'shuffles' },
  ];
  const [value, setValue] = useState<number>(0);
  const navigate = useNavigate();
  const location = useLocation();

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  useEffect(() => {
    navigate(`${location.pathname}/competitors`);
  }, []);

  return (
    <div className='wrapper'>
      <div className='competition-name'>
        Кубок України серед старших юнаків, юніорів, дорослих
      </div>
      <Tabs value={value} onChange={handleChange}>
        {tabLabels?.map((item, index) => (
          <Tab
            key={index}
            label={item.label}
            component={Link}
            to={`${item.link}`}
          />
        ))}
      </Tabs>
      <Outlet />
    </div>
  );
};

export { Competition };