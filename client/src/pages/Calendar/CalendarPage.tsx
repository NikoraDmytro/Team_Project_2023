import React, { useState } from 'react';
import './Calendar.scss';
import { DataTable } from '../../components/DataTable';

const CalendarPage = (): JSX.Element => {
  const [competitions, setCompetitions] = useState(test);
  return (
    <>
      <DataTable tableRows={competitions} tableColumns={columns} />
    </>
  );
};

export { CalendarPage };

const columns = [
  {
    name: 'Назва',
    sortable: true,
  },
  {
    name: 'Дата зважування',
    sortable: true,
  },
  {
    name: 'Дата початку',
    sortable: true,
  },
  {
    name: 'Дата закінчення',
    sortable: true,
  },
  {
    name: 'Місто',
    sortable: true,
  },
  {
    name: 'Статус',
    sortable: true,
  },
  {
    name: 'Рівень',
    sortable: true,
  },
];

const test = [
  {
    name: 'Кубок України серед старших юнаків, юніорів, дорослих',
    weightingDate: '2022-02-03',
    startDate: '2022-02-04',
    endData: '2022-02-06',
    city: 'Черкаси',
    status: 'очікується',
    level: 'Кубок України',
  },
  {
    name: 'Чемпіонат України серед старших юнаків, юніорів, дорослих',
    weightingDate: '2023-02-16',
    startDate: '2023-02-16',
    endData: '2023-02-19',
    city: 'Вінниця',
    status: 'прийом заявок',
    level: 'Чемпіонат України',
  },
  {
    name: 'Чемпіонат Вінницької області',
    weightingDate: '2023-02-03',
    startDate: '2023-02-03',
    endData: '2023-02-05',
    city: 'Вінниця',
    status: 'прийом заявок',
    level: 'Чемпіонат/кубок області',
  },
  {
    name: 'Чемпіонат Дніпропетровській області',
    weightingDate: '2023-01-28',
    startDate: '2023-01-28',
    endData: '2023-01-28',
    city: 'Дніпро',
    status: 'закінчено',
    level: 'Чемпіонат/кубок області',
  },
  {
    name: 'Відкритий Кубок Полтавської області',
    weightingDate: '2022-12-10',
    startDate: '2022-12-10',
    endData: '2022-12-10',
    city: 'Полтава',
    status: 'закінчено',
    level: 'Чемпіонат/кубок області',
  },
  {
    name: 'Відкритий кубок міста Вінниці',
    weightingDate: '2022-12-09',
    startDate: '2022-12-09',
    endData: '2022-12-10',
    city: 'Вінниця',
    status: 'закінчено',
    level: 'Інші всеукраїнські турніри',
  },
  {
    name: 'Кубок Любарта 2022',
    weightingDate: '2022-12-04',
    startDate: '2022-12-04',
    endData: '2022-12-04',
    city: 'Луцьк',
    status: 'закінчено',
    level: 'Чемпіонат/кубок області',
  },
  {
    name: 'Відкритий турнір СК "Прайд"',
    weightingDate: '2022-04-23',
    startDate: '2022-04-23',
    endData: '2022-04-23',
    city: 'Запоріжжя',
    status: 'скасовано',
    level: 'Інші турніри',
  },
];
