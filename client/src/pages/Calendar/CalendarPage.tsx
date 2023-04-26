import {
  Button,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TablePagination,
  TableRow,
  TextField,
} from '@mui/material';
import React, { useState } from 'react';
import CalendarItem from './CalendarItem';
import './Calendar.scss';

const CalendarPage = (): JSX.Element => {
  const [competitions, setCompetitions] = useState(test);
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);
  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>,
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };
  return (
    <div className='calendar-wrapper'>
      <div className='calendar-menu'>
        <TextField label='місце для пошуку'></TextField>
        <TextField label='місце для фільтрації'></TextField>
        <Button variant='contained'>Додати змагання</Button>
      </div>
      <Table stickyHeader>
        <TableHead>
          <TableRow>
            <TableCell>Назва</TableCell>
            <TableCell>Дата зважування</TableCell>
            <TableCell>Дата початку</TableCell>
            <TableCell>Дата закінчення</TableCell>
            <TableCell>Місто</TableCell>
            <TableCell>Статус</TableCell>
            <TableCell>Рівень</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {competitions.map((el, id) => (
            <CalendarItem key={id} el={el} />
          ))}
        </TableBody>
      </Table>
      <TablePagination
        rowsPerPageOptions={[5, 10, 25]}
        component='div'
        count={competitions.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </div>
  );
};

export { CalendarPage };

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
