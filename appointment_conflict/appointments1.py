# https://www.geeksforgeeks.org/given-n-appointments-find-conflicting-appointments/
# https://stackoverflow.com/questions/65580609/given-a-list-of-appointments-find-all-the-conflicting-appointments

def conflict(list):
    for a in range(len(list)):
        aStart = list[a][0]
        aEnd = list[a][1]

        for b in range(a+1, len(list)):

            bStart = list[b][0]
            bEnd = list[b][1]

            # if the start of the second appointment is before the end of the first appointment
            #   and the end of the second appointment is after the start of the first appointment
            # conflict due to overlap
            # note: first appointment ending on second appointment start is not considered an overlap conflict
            if(bStart < aEnd and bEnd > aStart):
                print(f'[{aStart}, {aEnd}] conficts with [{bStart}, {bEnd}]')

def visual(list):
    print('input:')
    print(list)
    print('calendar:')

    padding = 3
    min = list[0][0]
    max = list[0][1]

    for date in list:
        if(min > date[0]):
            min = date[0]
        if(max < date[1]):
            max = date[1]

    # header
    for num in range(min, max+1):
        print(f'{num}'.ljust(padding), end='')
    print()
    # 
    for date in list: 
        print(' ' * (date[0]-min) *padding, end='')
        print(f'{date[0]}'.ljust(padding, '-'), end='')

        print('-' * ((date[1]-date[0]-1) * padding), end='')
        print(f'{date[1]}')
    
appointments =[]
appointments.append([[3,7],[2,6],[10,15],[5,6]])
appointments.append([[4,5],[2,3],[3,6],[5,7],[7,8]])
appointments.append([[1,5],[3,7],[2,6],[10,15],[5,6]])

for dates in appointments:
    visual(dates)
    print('output:')
    conflict(dates)
    print('~'*42)