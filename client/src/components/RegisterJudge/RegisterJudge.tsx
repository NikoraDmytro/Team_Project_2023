import React, { useState } from 'react';
import { TableColumns } from '../../types/DataTableTypes';
import { Button, Dialog, TextField, Checkbox } from '@mui/material';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import judgeCategory from '../../const/judgeCategory';
import { DataTable } from '../DataTable';

interface RegisterJudgeFormProps {
  open: boolean;
  setClose: () => void;
}

type Judge = (typeof test)[0];
type ColumnsType = Judge & { controls: string };

const RegisterJudge = (props: RegisterJudgeFormProps) => {
  const { open, setClose } = props;

  const [judges, setJudges] = useState(test);
  const [selectedClub, setSelectedClub] = useState('');
  const [selectedCategory, setSelectedCategory] = useState('');
  const handleChange = (field: string, value: string) => {
    if (field === 'club') {
      setSelectedClub(value);
      setJudges(prev => prev.filter(judge => judge.club === value));
    } else {
      setSelectedCategory(value);
      setJudges(prev => prev.filter(judge => judge.judgeCategory === value));
    }
  };

  const columns: TableColumns<Judge, ColumnsType>[] = [
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
      name: 'judgeCategory',
      label: 'Суддівська категорія',
    },
    {
      name: 'membershipCardNum',
      label: 'Номер членського квитка',
    },
  ];
  return (
    <Dialog open={open} onClose={setClose} maxWidth='lg'>
      <div className='menu'>
        <TextField label='Пошук' />
        <div className='groups-filters'>
          <div className='filter-buttons1'>
            <SelectForFilter
              label='Клуб'
              items={clubsTest}
              name='club'
              setFieldValue={handleChange}
            />
            <SelectForFilter
              label='Категорія'
              items={judgeCategory}
              name='judgeCategory'
              setFieldValue={handleChange}
            />
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
      <DataTable tableData={judges} tableColumns={columns} />
    </Dialog>
  );
};

export { RegisterJudge };

const test = [
  {
    id: 1,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 2,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 3,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 4,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 5,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 6,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 7,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 8,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 9,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
  {
    id: 10,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '1970-02-06',
    club: 'СК "ПРАЙД"',
    belt: '3 дан',
    judgeCategory: 'Суддя 1-ї категорії',
    membershipCardNum: '123456',
  },
];
const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];
