#!/bin/bash

NOTICE_FILE=~/scratch/NOTICE
FILE=NOTICE

if [ ! -f "$FILE" ]; then
    touch $FILE
    cat $NOTICE_FILE >> $FILE
fi
