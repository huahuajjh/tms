<style>
    .calendar-input {
        cursor: auto !important;
        background-color: #fff !important;
    }
</style>
<template>
    <div class="input-group calendar-drp-popup">
        <input type="text" class="form-control calendar-input" v-model="showValue" readonly @focus="show = true" @blur="show = false">
        <a href="javascript:;" class="input-group-addon" @click="startdate = enddate = ''">取消选择</a>
        <div class="drp-popup" v-show="show">
            <div class="drp-timeline">
                <ul class="drp-timeline-presets">
                    <li :class="{ 'drp-selected': sectionNum == 7 }" @click="setRange(7)">7 天<div class="drp-button"></div></li>
                    <li :class="{ 'drp-selected': sectionNum == 15 }" @click="setRange(15)">15<div class="drp-button"></div></li>
                    <li :class="{ 'drp-selected': sectionNum == 30 }" @click="setRange(30)">30 天<div class="drp-button"></div></li>
                    <li :class="{ 'drp-selected': sectionNum == 90 }" @click="setRange(90)">90 天<div class="drp-button"></div></li>
                    <li :class="{ 'drp-selected': sectionNum == 180 }" @click="setRange(180)">180 天<div class="drp-button"></div></li>
                    <li :class="{ 'drp-selected': sectionNum == 365 }" @click="setRange(365)">365 天<div class="drp-button"></div></li>
                </ul>
                <div class="drp-timeline-bar"></div>
            </div>
            <div class="drp-calendars">
                <div class="drp-calendar drp-calendar-start">
                    <div class="drp-month-picker">
                        <div class="drp-arrow" @click="showPreviousMonth(true)">&lt;</div>
                        <div class="drp-month-title">{{start.year}} {{months[start.month]}}</div>
                        <div class="drp-arrow drp-arrow-right" @click="showNextMonth(true)">&gt;</div>
                    </div>
                    <ul class="drp-day-headers">
                        <li>日</li>
                        <li>一</li>
                        <li>二</li>
                        <li>三</li>
                        <li>四</li>
                        <li>五</li>
                        <li>六</li>
                    </ul>
                    <ul class="drp-days">
                        <li class="drp-day" v-for="day in start.days" :class="day.type" @click="setDay(true, day)">{{day.value}}</li>
                    </ul>
                </div>
                <div class="drp-calendar-separator"></div>
                <div class="drp-calendar drp-calendar-end">
                    <div class="drp-month-picker">
                        <div class="drp-arrow" @click="showPreviousMonth(false)">&lt;</div>
                        <div class="drp-month-title">{{end.year}} {{months[end.month]}}</div>
                        <div class="drp-arrow drp-arrow-right" @click="showNextMonth(false)">&gt;</div>
                    </div>
                    <ul class="drp-day-headers">
                        <li>日</li>
                        <li>一</li>
                        <li>二</li>
                        <li>三</li>
                        <li>四</li>
                        <li>五</li>
                        <li>六</li>
                    </ul>
                    <ul class="drp-days">
                        <li class="drp-day" v-for="day in end.days" :class="day.type" @click="setDay(false, day)">{{day.value}}</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>
<script>

    import datetime, { stringToDate } from "../../js/filter/datetime.js";

    export default {
        props: {
            setting: {
                type: Boolean,
                default: false
            },
            format: {
                type: String,
                default: "yyyy/MM/dd"
            },
            startdate: {
                type: String,
                twoWay: true
            },
            enddate: {
                type: String,
                twoWay: true
            }
        },
        computed: {
            showValue() {
                if(!this.startdate || !this.enddate) return "";
                return this.startdate + "到" + this.enddate;
            }
        },
        data() {
            var startDate = new Date();
            var endtDate = new Date();
            if(this.startdate && this.enddate) {
                var startTime = stringToDate(this.startdate);
                if(startTime != null) startDate = startTime;
                var endTime = stringToDate(this.enddate);
                if(endTime != null) endtDate = endTime;
            }
            startDate.setHours(0, 0, 0, 0);
            endtDate.setHours(0, 0, 0, 0);
            return {
                months: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
                start: {
                    month: startDate.getMonth(),
                    year: startDate.getFullYear(),
                    date: startDate,
                    days: []
                },
                end: {
                    month: endtDate.getMonth(),
                    year: endtDate.getFullYear(),
                    date: endtDate,
                    days: []
                },
                sectionNum: 0,
                show: false
            };
        },
        ready() {
            this.drawDays(true);
            this.drawDays(false);
        },
        methods: {
            initValue() {
                this.startdate = datetime(this.start.date, this.format);
                this.enddate = datetime(this.end.date, this.format);
            },
            setRange(daysAgo) {
                if(this.setting) {
                    var endDate = new Date(this.start.date.getTime());
                    endDate.setDate(endDate.getDate() + daysAgo);
                    this.end.date = endDate;
                    this.end.month = endDate.getMonth();
                    this.end.year = endDate.getFullYear();
                } else {
                    var startDate = new Date(this.end.date.getTime());
                    startDate.setDate(startDate.getDate() - daysAgo);
                    this.start.date = startDate;
                    this.start.month = startDate.getMonth();
                    this.start.year = startDate.getFullYear();
                }
                this.drawDays(true);
                this.drawDays(false);
                this.initValue();
            },
            initSectionNum() {
                this.sectionNum = parseInt((this.end.date.getTime() - this.start.date.getTime()) / (1000 * 60 * 60 * 24));
            },
            showNextMonth(isStart) {
                var date = isStart ? this.start : this.end;
                if (date.month + 1 > 11) {
                    date.month = 0
                    date.year += 1
                } else {
                    date.month += 1
                }
                this.drawDays(isStart);
            },
            showPreviousMonth(isStart) {
                var date = isStart ? this.start : this.end;
                if (date.month - 1 < 0) {
                    date.month = 11
                    date.year -= 1
                } else {
                    date.month -= 1
                }
                this.drawDays(isStart);
            },
            setDay(isStart, day) {
                if(day.type.indexOf("drp-day-disabled") !== -1) return;
                var date = isStart ? this.start : this.end;
                date.date = new Date(date.year, date.month, day.value);
                this.drawDays(true);
                this.drawDays(false);
                this.initValue();
            },
            drawDays(isStart) {
                var date = isStart ? this.start : this.end;
                var firstDayOfMonth = new Date(date.year, date.month, 1).getDay() + 1;
                var lastDayOfMonth = new Date(date.year, date.month + 1, 0).getDate();
                var days = date.days = date.days.slice(0,0);
                for (var i = 1, _ref = firstDayOfMonth - 1; i <= _ref; i += 1) {
                    days.push({
                        type: "drp-day-empty"
                    });
                }
                for (var i = 1; i <= lastDayOfMonth; i += 1) {
                    days.push(this.dayType(isStart, i, firstDayOfMonth, lastDayOfMonth));
                }
                this.initSectionNum();
            },
            dayType(isStart, day, firstDayOfMonth, lastDayOfMonth) {
                var dateTime = isStart ? this.start : this.end;
                var date = new Date(dateTime.year, dateTime.month, day);
                var typeVal = "";
                var time = dateTime.date.getTime();
                if (time == date.getTime()) {
                    typeVal = "drp-day-selected";
                } else if (date >= this.start.date && date <= this.end.date) {
                    typeVal = 'drp-day-in-range';
                    if (date.getTime() === this.end.date.getTime()) {
                        typeVal += ' drp-day-last-in-range'
                    }
                } else if (isStart) {
                    if (date > this.end.date) {
                        typeVal = ' drp-day-disabled'
                    }
                } else if (date < this.start.date) {
                    typeVal = ' drp-day-disabled'
                }
                if ((day + firstDayOfMonth - 1) % 7 === 0 || day === lastDayOfMonth) {
                    typeVal += ' drp-day-last-in-row'
                }
                return {
                    type: typeVal,
                    value: day
                }
            }
        }
    }
</script>