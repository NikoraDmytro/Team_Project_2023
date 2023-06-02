import React, { useState } from 'react';
import { Button, Dialog, TextField, Checkbox } from '@mui/material';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import { DataTable } from '../DataTable';
import { TableColumns } from '../../types/DataTableTypes';
import '../../pages/Competition/Competition.scss';

interface RegisterSportsmenFormProps {
  open: boolean;
  setClose: () => void;
}
type Sporstman = (typeof test)[0];
type ColumnsType = Sporstman & { controls: string };

const RegisterSportsmen = (props: RegisterSportsmenFormProps) => {
  const { open, setClose } = props;

  const [sportsmen, setSportsmen] = useState(test);

  const columns: TableColumns<Sporstman, ColumnsType>[] = [
    {
      name: 'controls',
      renderItem: () => <Checkbox />,
    },
    {
      name: 'photo',
      label: 'Фото',
    },
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'sex',
      label: 'Стать',
    },
    {
      name: 'birthday',
      label: 'Дата народження',
      sortable: true,
    },
    {
      name: 'club',
      label: 'Клуб',
    },
    {
      name: 'belt',
      label: 'Статус',
    },
    {
      name: 'coach',
      label: 'Прокопенко Ю.С.',
    },
    {
      name: 'membershipCardNum',
      label: 'Номер членського квитка',
    },
  ];
  return (
    <Dialog
      open={open}
      onClose={setClose}
      maxWidth='lg'
    >
      <div className='menu'>
        <TextField label='Пошук' />
        <div className='groups-filters'>
          <div className='filter-buttons1'>
            <SelectForFilter label='Стать' items={['Ч', 'Ж']} />
            <SelectForFilter label='Клуб' items={clubsTest} />
            <SelectForFilter label='Тренер' items={coachesTest} />
          </div>
          <div className='filter-buttons2'>
            <SelectForFilter label='Мін пояс' items={belts} />
            <SelectForFilter label='Макс пояс' items={belts} />
            <TextField label='Мін вік' />
            <TextField label='Макс вік' />
          </div>
        </div>
        <Button variant='contained' color='inherit' onClick={setClose}>
          Зареєструвати
        </Button>
      </div>
      <DataTable tableData={sportsmen} tableColumns={columns} />
    </Dialog>
  );
};

export { RegisterSportsmen };

const test = [
  {
    id: 1,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
  {
    id: 2,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
  {
    id: 3,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
  {
    id: 4,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
  {
    id: 5,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
  {
    id: 6,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
  {
    id: 7,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
];

const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];
const coachesTest = ['Прокопенко Ю.С.', 'Прокопенко Ю.С.', 'Прокопенко Ю.С.'];
