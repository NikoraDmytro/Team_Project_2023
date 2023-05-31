import { Tab, Tabs } from '@mui/material';
import React, { useState } from 'react';
import { Link, Outlet } from 'react-router-dom';
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

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

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

// const location = useLocation();
// 	const currentLocation = tabLabels.findIndex(
// 		el => el.key === location.pathname.split('/').at(-1),
// 	);
// 	const [value, setValue] = useState(currentLocation);

// 	const handleChange = (event, newValue) => {
// 		setValue(newValue);
// 	};

// 	useEffect(() => {
// 		setValue(currentLocation);
// 	}, [location.pathname]);

// 	return (
// 		<div className={styles.mainInfo}>
// 			<Tabs value={value !== -1 ? value : 0} onChange={handleChange}>
// 				{tabLabels?.map((item, index) => (
// 					<Tab
// 						key={index}
// 						label={item.label}
// 						component={Link}
// 						to={`${item.link}`}
// 						sx={{ fontSize: '20px' }}
// 					/>
// 				))}
// 			</Tabs>
// 			<Outlet context={{ ...user, isTalentProfile: isUserProfile }} />
// 		</div>
// 	);
