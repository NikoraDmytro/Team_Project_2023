import React, { useState } from 'react';
import './Calendar.scss';
import { DataTable } from '../../components/DataTable';
import { Button, TextField } from '@mui/material';
import { TableColumns } from '../../types/DataTableTypes';

type Competition = (typeof test)[0];
type ColumnsType = Competition & { controls: string };

const CalendarPage = (): JSX.Element => {
  const [competitions, setCompetitions] = useState(test);

  const columns: TableColumns<Competition, ColumnsType>[] = [
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'weightingDate',
      label: 'Дата зважування',
    },
    {
      name: 'startDate',
      label: 'Дата початку',
      sortable: true,
    },
    {
      name: 'endData',
      label: 'Дата закінчення',
    },
    {
      name: 'city',
      label: 'Місто',
    },
    {
      name: 'status',
      label: 'Статус',
      sortable: true,
    },
    {
      name: 'level',
      label: 'Рівень',
    },
    {
      name: 'controls',
      renderItem: () => <div>Buttons here!</div>,
    },
  ];

  return (
    <div className='calendar-wrapper'>
      <div className='calendar-menu'>
        <TextField label='місце для пошуку'></TextField>
        <TextField label='місце для фільтрації'></TextField>
        <Button variant='contained'>Додати змагання</Button>
      </div>

      <DataTable tableData={competitions} tableColumns={columns} />
    </div>
  );
};

export { CalendarPage };

const test = [
  {
    id: 1,
    name: 'Кубок України серед старших юнаків, юніорів, дорослих',
    weightingDate: '2022-02-03',
    startDate: '2022-02-04',
    endData: '2022-02-06',
    city: 'Черкаси',
    status: 'очікується',
    level: 'Кубок України',
  },
  {
    id: 2,
    name: 'Чемпіонат України серед старших юнаків, юніорів, дорослих',
    weightingDate: '2023-02-16',
    startDate: '2023-02-16',
    endData: '2023-02-19',
    city: 'Вінниця',
    status: 'прийом заявок',
    level: 'Чемпіонат України',
  },
  {
    id: 3,
    name: 'Чемпіонат Вінницької області',
    weightingDate: '2023-02-03',
    startDate: '2023-02-03',
    endData: '2023-02-05',
    city: 'Вінниця',
    status: 'прийом заявок',
    level: 'Чемпіонат/кубок області',
  },
  {
    id: 4,
    name: 'Чемпіонат Дніпропетровській області',
    weightingDate: '2023-01-28',
    startDate: '2023-01-28',
    endData: '2023-01-28',
    city: 'Дніпро',
    status: 'закінчено',
    level: 'Чемпіонат/кубок області',
  },
  {
    id: 5,
    name: 'Відкритий Кубок Полтавської області',
    weightingDate: '2022-12-10',
    startDate: '2022-12-10',
    endData: '2022-12-10',
    city: 'Полтава',
    status: 'закінчено',
    level: 'Чемпіонат/кубок області',
  },
  {
    id: 6,
    name: 'Відкритий кубок міста Вінниці',
    weightingDate: '2022-12-09',
    startDate: '2022-12-09',
    endData: '2022-12-10',
    city: 'Вінниця',
    status: 'закінчено',
    level: 'Інші всеукраїнські турніри',
  },
  {
    id: 7,
    name: 'Кубок Любарта 2022',
    weightingDate: '2022-12-04',
    startDate: '2022-12-04',
    endData: '2022-12-04',
    city: 'Луцьк',
    status: 'закінчено',
    level: 'Чемпіонат/кубок області',
  },
  {
    id: 8,
    name: 'Відкритий турнір СК "Прайд"',
    weightingDate: '2022-04-23',
    startDate: '2022-04-23',
    endData: '2022-04-23',
    city: 'Запоріжжя',
    status: 'скасовано',
    level: 'Інші турніри',
  },
];
